import { useContext } from "react";
import { AuthContext } from "../../contexts/Auth/AuthContext";

export const Private = () =>{
    const auth = useContext(AuthContext);
    console.log(auth.user?.userName);
    
    return(
        <div>
            <h2>Área Restrita</h2>

            Olá {auth.user?.userName}
        </div>
    );
}
