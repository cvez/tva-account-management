import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import api from '../services/api';
import './Persons.css';

function Persons() {
  const [persons, setPersons] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    fetchPersons();
  }, []);

  const fetchPersons = async () => {
    try {
      const response = await api.get('/persons');
      setPersons(response.data);
    } catch (error) {
      console.error('Error fetching persons:', error);
    }
  };

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
  };

  const handleCreate = () => {
    navigate('/persons/new');
  };

  const handleEdit = (id) => {
    navigate(`/persons/${id}`);
  };

  const handleDelete = async (id) => {
    const person = persons.find(p => p.id === id);
    if (person.accounts && person.accounts.some(account => account.balance !== 0)) {
      alert('Cannot delete person with active accounts.');
      return;
    }
    try {
      await api.delete(`/persons/${id}`);
      fetchPersons();
    } catch (error) {
      console.error('Error deleting person:', error);
    }
  };

  return (
    <div className="persons">
      <h1>Persons</h1>
      <input
        type="text"
        placeholder="Search by ID, Surname, or Account Number"
        value={searchTerm}
        onChange={handleSearch}
      />
      <ul>
        {persons
          .filter(person =>
            person.id.includes(searchTerm) ||
            person.surname.toLowerCase().includes(searchTerm.toLowerCase()) ||
            person.accountNumber.includes(searchTerm)
          )
          .map(person => (
            <li key={person.id}>
              <Link to={`/persons/${person.id}`}>{person.name}</Link>
              <button onClick={() => handleEdit(person.id)}>Edit</button>
              <button onClick={() => handleDelete(person.id)}>Delete</button>
            </li>
          ))}
      </ul>
      <button onClick={handleCreate}>Create New Person</button>
    </div>
  );
}

export default Persons;