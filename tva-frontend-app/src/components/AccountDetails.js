import React, { useState, useEffect, useCallback } from 'react';
import { useParams, useNavigate, useLocation, Link } from 'react-router-dom';
import api from '../services/api';
import './AccountDetails.css';

function AccountDetails() {
  const { id } = useParams();
  const navigate = useNavigate();
  const location = useLocation();
  const [account, setAccount] = useState({
    id: '',
    accountNumber: '',
    balance: 0,
    personId: new URLSearchParams(location.search).get('personId'),
    transactions: []
  });
  const [accounts, setAccounts] = useState([]);

  const fetchAccountDetails = useCallback(async () => {
    try {
      const response = await api.get(`/accounts/${id}`);
      setAccount(response.data);
    } catch (error) {
      console.error('Error fetching account details:', error);
    }
  }, [id]);

  const fetchAccounts = useCallback(async () => {
    try {
      const response = await api.get('/accounts');
      setAccounts(response.data);
    } catch (error) {
      console.error('Error fetching accounts:', error);
    }
  }, []);

  useEffect(() => {
    if (id !== 'new') {
      fetchAccountDetails();
    }
    fetchAccounts();
  }, [id, fetchAccountDetails, fetchAccounts]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setAccount({ ...account, [name]: value });
  };

  const handleSave = async () => {
    if (!account.accountNumber) {
      alert('Account Number is required.');
      return;
    }

    if (id === 'new' && accounts.some(a => a.accountNumber === account.accountNumber)) {
      alert('Account with this Account Number already exists.');
      return;
    }

    try {
      if (id === 'new') {
        await api.post('/accounts', account);
      } else {
        await api.put(`/accounts/${id}`, account);
      }
      navigate(`/persons/${account.personId}`);
    } catch (error) {
      console.error('Error saving account:', error);
    }
  };

  const handleAddTransaction = () => {
    navigate(`/transactions/new?accountId=${account.id}`);
  };

  return (
    <div className="account-details">
      <h1>Account Details</h1>
      <input
        type="text"
        name="accountNumber"
        placeholder="Account Number"
        value={account.accountNumber}
        onChange={handleChange}
      />
      <p>Balance: {account.balance}</p>
      <button onClick={handleSave}>Save</button>
      <h2>Transactions</h2>
      <ul>
        {account.transactions.map(transaction => (
          <li key={transaction.id}>
            <Link to={`/transactions/${transaction.id}`}>{transaction.description}</Link>
            <button onClick={() => navigate(`/transactions/${transaction.id}`)}>Edit</button>
          </li>
        ))}
      </ul>
      <button onClick={handleAddTransaction}>Add New Transaction</button>
    </div>
  );
}

export default AccountDetails;