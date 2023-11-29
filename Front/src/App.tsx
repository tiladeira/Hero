import React, { useContext } from 'react';
import './App.css';
import { Route, Routes, Link } from 'react-router-dom';
import { Home } from './pages/Home';
import { Private } from './pages/Private';
import { RequireAuth } from './contexts/Auth/RequireAuth';
import { AuthContext } from './contexts/Auth/AuthContext';
import { Login } from './pages/Login';

function App() {
  const auth = useContext(AuthContext);

  const handleLogout = async () =>{
    await auth.singout();
    window.location.href = window.location.href;
  }

  return (
    <div className="App">
      <header>
        <h1>HERO</h1>
        <nav>
          <Link to="/">Home</Link>&nbsp;||&nbsp;          
          <Link to="/Private">Página Privada</Link>&nbsp;||&nbsp;  
          {!auth.user && <button onClick={handleLogout}>Login</button>}
          {auth.user && <button onClick={handleLogout}>Sair</button>}
        </nav>
      </header>
      <hr />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/Private" element={<RequireAuth><Private /></RequireAuth>} />
      </Routes>
      <div>
        Escopo do Desafio
      </div>
    </div>
  );
}

export default App;
