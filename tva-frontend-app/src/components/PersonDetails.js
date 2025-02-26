import React, { useState, useEffect, useCallback } from 'react';
import { useParams, useNavigate, Link } from 'react-router-dom';
import api from '../services/api';
import './PersonDetails.css';

function PersonDetails() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [person, setPerson] = useState({
    id: '',
    idNumber: '',
    surname: '',
    name: '',
    accounts: []
  });
  const [persons, setPersons] = useState([]);

  const fetchPersonDetails = useCallback(async () => {
    try {
      const response = await api.get(`/persons/${id}`);
      setPerson(response.data);
    } catch (error) {
      console.error('Error fetching person details:', error);
    }
  }, [id]);

  const fetchPersons = useCallback(async () => {
    try {
      const response = await api.get('/persons');
      setPersons(response.data);
    } catch (error) {
      console.error('Error fetching persons:', error);
    }
  }, []);

  useEffect(() => {
    if (id !== 'new') {
      fetchPersonDetails();
    }
    fetchPersons();
  }, [id, fetchPersonDetails, fetchPersons]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setPerson({ ...person, [name]: value });
  };

  const handleSave = async () => {
    if (!person.idNumber || !person.surname || !person.name) {
      alert('All fields are required.');
      return;
    }

    if (id === 'new' && persons.some(p => p.idNumber === person.idNumber)) {
      alert('Person with this ID Number already exists.');
      return;
    }

    try {
      if (id === 'new') {
        await api.post('/persons', person);
      } else {
        await api.put(`/persons/${id}`, person);
      }
      navigate('/persons');
    } catch (error) {
      console.error('Error saving person:', error);
    }
  };

  const handleAddAccount = () => {
    navigate(`/accounts/new?personId=${person.id}`);
  };

  return (
    <div className="person-details">
      <h1>Person Details</h1>
      <input
        type="text"
        name="idNumber"
        placeholder="ID Number"
        value={person.idNumber}
        onChange={handleChange}
      />
      <input
        type="text"
        name="surname"
        placeholder="Surname"
        value={person.surname}
        onChange={handleChange}
      />
      <input
        type="text"
        name="name"
        placeholder="Name"
        value={person.name}
        onChange={handleChange}
      />
      <button onClick={handleSave}>Save</button>
      <h2>Accounts</h2>
      <ul>
        {person.accounts.map(account => (
          <li key={account.id}>
            <Link to={`/accounts/${account.id}`}>{account.accountNumber}</Link>
            <button onClick={() => navigate(`/accounts/${account.id}`)}>Edit</button>
          </li>
        ))}
      </ul>
      <button onClick={handleAddAccount}>Add New Account</button>
    </div>
  );
}

export default PersonDetails;