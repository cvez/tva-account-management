import React, { useState, useEffect, useCallback } from 'react';
import { useParams, useNavigate, Link } from 'react-router-dom';
import { fetchPersonById, fetchPersons, addPerson, updatePerson } from '../services/api';
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
  const [message, setMessage] = useState('');

  const fetchPersonDetails = useCallback(async () => {
    try {
      const data = await fetchPersonById(id);
      setPerson(data);
    } catch (error) {
      console.error('Error fetching person details:', error);
    }
  }, [id]);

  const fetchAllPersons = useCallback(async () => {
    try {
      const data = await fetchPersons();
      setPersons(data);
    } catch (error) {
      console.error('Error fetching persons:', error);
    }
  }, []);

  useEffect(() => {
    if (id !== 'new') {
      fetchPersonDetails();
    }
    fetchAllPersons();
  }, [id, fetchPersonDetails, fetchAllPersons]);

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
        await addPerson(person);
        setMessage('New person has been created successfully!');
      } else {
        await updatePerson(id, person);
        setMessage('Person details have been updated successfully!');
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
      {message && <p className="message">{message}</p>}
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