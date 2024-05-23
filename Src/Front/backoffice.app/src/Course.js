// src/Course.js
import React, { useState } from 'react';
import axios from 'axios';
import './Course.css';

const Course = () => {
  const [formData, setFormData] = useState({
    name: '',
    price: '',
	billingType: ''
  });
  
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
	try {
      const response = await axios.post('https://localhost:44375/api/Course', formData, {
        headers: {
          'Content-Type': 'application/json',
		  'Access-Control-Allow-Origin': 'http://localhost:3000'
        }
      });
	  console.log('Response:', response.data);
	  setSuccessMessage('Cadastro realizado com sucesso!');
	}
	catch (error) {
		console.error('Erro ao enviar os dados:', error);
		setErrorMessage('Falha ao realizar o cadastro: ' + error);
	}
	
	console.log('Dados enviados:', formData);
    
  };

  return (
    <div className="Cadastro">
      <h2>Cadastro de Curso</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name">Nome do curso:</label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="price">Preco:</label>
          <input
            type="price"
            id="price"
            name="price"
            value={formData.price}
            onChange={handleChange}
            required
          />
        </div>
		<div className="form-group">
          <label htmlFor="billingType">Tipo de faturamento:</label>
          <select 
			id="billingType" 
			name="billingType"
			value={formData.billingType}
			onChange={handleChange}
			required >
				<option value="">Selecione</option>
				<option value="1">Assinatura</option>
				<option value="2">One time</option>
		  </select>		  
        </div>
        <button type="submit">Cadastrar</button>
      </form>
	  {successMessage && <p className="success-message">{successMessage}</p>}
	  {errorMessage && <p className="error-message">{errorMessage}</p>}
    </div>
  );
};

export default Course;
