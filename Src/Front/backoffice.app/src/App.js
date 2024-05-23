import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Course from './Course';

function App() {
  return (
    <div className="App">
		<Routes>
			<Route path="/">  
			
			</Route> 
			<Route path="/course" element={<Course/>} />		
		</Routes>	
    </div>
  );
}

export default App;
