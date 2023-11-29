import { ChangeEvent, useContext, useState } from "react";
import { AuthContext } from "../../contexts/Auth/AuthContext";
import { useNavigate } from "react-router-dom";

export const Login = () => {
    const auth = useContext(AuthContext);
    const navigate = useNavigate();

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleUsernameInput = (e: ChangeEvent<HTMLInputElement>) => {
        setUsername(e.target.value);
    }

    const handlePasswordlInput = (e: ChangeEvent<HTMLInputElement>) => {
        setPassword(e.target.value);
    }

    const handleLogin = async () => {
        if(username && password){
            const isLogged = await auth.singin(username, password);
            console.log('logado?' + isLogged);

            if(isLogged){
                navigate('/');
            }
        }
    }

    return(
        <div>
            <h2>Login</h2>
            <input
                type="text"
                value={username}
                onChange={handleUsernameInput}
                placeholder="Login"
            />
            <input
                type="password"
                value={password}
                onChange={handlePasswordlInput}
                placeholder="Password"
            />
            <button onClick={handleLogin}>Login</button>
        </div>
    );
}