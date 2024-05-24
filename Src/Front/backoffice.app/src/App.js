import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Course from './Course';
import ListCourses from './ListCourses';

function App() {
  return (
    <div className="App">
		<Routes>
			<Route path="/">  
			
			</Route> 
			<Route path="/course" element={<Course/>} />		
			<Route path="/list-courses" element={<ListCourses/>} />
		</Routes>	
    </div>
  );
}

export default App;
