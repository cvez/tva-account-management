import React, { useState, useEffect, useCallback } from 'react';
import { useParams, useNavigate, useLocation } from 'react-router-dom';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { fetchTransactionById, addTransaction, updateTransaction } from '../services/api';
import './TransactionDetails.css';

function TransactionDetails() {
  const { id } = useParams();
  const navigate = useNavigate();
  const location = useLocation();
  const [transaction, setTransaction] = useState({
    id: '',
    description: '',
    amount: 0,
    date: new Date(),
    captureDate: new Date(),
    accountId: new URLSearchParams(location.search).get('accountId')
  });

  const fetchTransactionDetails = useCallback(async () => {
    try {
      const data = await fetchTransactionById(id);
      setTransaction({ ...data, date: new Date(data.date) });
    } catch (error) {
      console.error('Error fetching transaction details:', error);
    }
  }, [id]);

  useEffect(() => {
    if (id !== 'new') {
      fetchTransactionDetails();
    }
  }, [id, fetchTransactionDetails]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setTransaction({ ...transaction, [name]: value });
  };

  const handleDateChange = (date) => {
    setTransaction({ ...transaction, date });
  };

  const handleSave = async () => {
    if (!transaction.description || !transaction.amount) {
      alert('Description and Amount are required.');
      return;
    }

    if (transaction.amount === 0) {
      alert('Transaction amount cannot be zero.');
      return;
    }

    if (transaction.date > new Date()) {
      alert('Transaction date cannot be in the future.');
      return;
    }

    try {
      if (id === 'new') {
        await addTransaction(transaction);
      } else {
        await updateTransaction(id, transaction);
      }
      navigate(`/accounts/${transaction.accountId}`);
    } catch (error) {
      console.error('Error saving transaction:', error);
    }
  };

  return (
    <div className="transaction-details">
      <h1>Transaction Details</h1>
      <input
        type="text"
        name="description"
        placeholder="Description"
        value={transaction.description}
        onChange={handleChange}
      />
      <input
        type="number"
        name="amount"
        placeholder="Amount"
        value={transaction.amount}
        onChange={handleChange}
      />
      <DatePicker
        selected={transaction.date}
        onChange={handleDateChange}
      />
      <button onClick={handleSave}>Save</button>
    </div>
  );
}

export default TransactionDetails;