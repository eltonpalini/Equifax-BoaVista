import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './ListCourses.css';

const ListCourses = () => {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const response = await axios.get('http://localhost:8080/api/Course');
        setCourses(response.data);
      } catch (error) {
        setError('Erro ao carregar os cursos');
      } finally {
        setLoading(false);
      }
    };

    fetchCourses();
  }, []);
  
  if (loading) {
    return <p>Carregando...</p>;
  }
  
   if (error) {
    return <p>{error}</p>;
  }
  
  return (
    <div className="ListCourses">
      <h2>Lista de Cursos</h2>
      {courses.length === 0 ? (
        <p>Nenhum curso encontrado.</p>
      ) : (
        <ul>
          {courses.map((course) => (
            <li key={course.id}>
              <p>Nome do curso: {course.name}</p>
              <p>Preco: {course.price}</p>
              <p>Tipo de faturamento: {course.billingType}</p>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default ListCourses;