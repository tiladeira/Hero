import { useEffect, useState } from "react";
import { AuthContext } from "./AuthContext";
import { User } from "../../types/User";
import { useApi } from "../../hooks/useApi";

export const AuthProvider = ({children} : { children: JSX.Element}) => {
    const [user, setUser] = useState<User | null>(null);
    const api = useApi();

    useEffect(() => {
        const validateToken = async () => {
            const storageData = localStorage.getItem('authToken');
            if(storageData){
                const data = await api.validateToken(storageData);
                if(data.user){
                    setUser(data.userName);
                }
            }
            setToken('');
            console.log(storageData);
        }

        validateToken();
    }, [api]);
    
    const singin = async (email: string, password: string) => {
        const data = await api.singin(email, password)
        console.log(data);
        if(data.user && data.token){
            setUser(data.user);
            setToken(data.token);
            return true;
        }
        return false;
    }

    const singout = async () => {
        setUser(null);
        setToken('');
        //await api.singout();
    }

    const setToken = async (token: string) => {
        localStorage.setItem('authToken', token)
    }

    return(
        <AuthContext.Provider value={{ user, singin, singout }}>
            {children}
        </AuthContext.Provider>
    );
}