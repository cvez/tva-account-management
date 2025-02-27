import axios from 'axios';

// Define the base URL for the API
const API_BASE_URL = 'http://localhost:5105/api';  // Replace with your backend URL and port

// Create an axios instance with the base URL
const api = axios.create({
  baseURL: API_BASE_URL,
});

// Function to fetch all persons
export const fetchPersons = async () => {
  try {
    const response = await api.get('/persons');
    return response.data;
  } catch (error) {
    console.error('Error fetching persons:', error);
    throw error;
  }
};

// Function to fetch a single person by ID
export const fetchPersonById = async (id) => {
  try {
    const response = await api.get(`/persons/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching person by ID:', error);
    throw error;
  }
};

// Function to add a new person
export const addPerson = async (person) => {
  try {
    const response = await api.post('/persons', person);
    return response.data;
  } catch (error) {
    console.error('Error adding person:', error);
    throw error;
  }
};

// Function to update a person
export const updatePerson = async (id, person) => {
  try {
    const response = await api.put(`/persons/${id}`, person);
    return response.data;
  } catch (error) {
    console.error('Error updating person:', error);
    throw error;
  }
};

// Function to delete a person
export const deletePerson = async (id) => {
  try {
    const response = await api.delete(`/persons/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting person:', error);
    throw error;
  }
};

// Function to fetch all transactions
export const fetchTransactions = async () => {
  try {
    const response = await api.get('/transactions');
    return response.data;
  } catch (error) {
    console.error('Error fetching transactions:', error);
    throw error;
  }
};

// Function to fetch a single transaction by ID
export const fetchTransactionById = async (id) => {
  try {
    const response = await api.get(`/transactions/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching transaction by ID:', error);
    throw error;
  }
};

// Function to add a new transaction
export const addTransaction = async (transaction) => {
  try {
    const response = await api.post('/transactions', transaction);
    return response.data;
  } catch (error) {
    console.error('Error adding transaction:', error);
    throw error;
  }
};

// Function to update a transaction
export const updateTransaction = async (id, transaction) => {
  try {
    const response = await api.put(`/transactions/${id}`, transaction);
    return response.data;
  } catch (error) {
    console.error('Error updating transaction:', error);
    throw error;
  }
};

// Function to delete a transaction
export const deleteTransaction = async (id) => {
  try {
    const response = await api.delete(`/transactions/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting transaction:', error);
    throw error;
  }
};

// Function to fetch all accounts
export const fetchAccounts = async () => {
  try {
    const response = await api.get('/accounts');
    return response.data;
  } catch (error) {
    console.error('Error fetching accounts:', error);
    throw error;
  }
};

// Function to fetch a single account by ID
export const fetchAccountById = async (id) => {
  try {
    const response = await api.get(`/accounts/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching account by ID:', error);
    throw error;
  }
};

// Function to add a new account
export const addAccount = async (account) => {
  try {
    const response = await api.post('/accounts', account);
    return response.data;
  } catch (error) {
    console.error('Error adding account:', error);
    throw error;
  }
};

// Function to update an account
export const updateAccount = async (id, account) => {
  try {
    const response = await api.put(`/accounts/${id}`, account);
    return response.data;
  } catch (error) {
    console.error('Error updating account:', error);
    throw error;
  }
};

// Function to delete an account
export const deleteAccount = async (id) => {
  try {
    const response = await api.delete(`/accounts/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting account:', error);
    throw error;
  }
};

export default api;