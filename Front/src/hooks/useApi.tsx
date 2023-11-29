import axios from "axios";

const api = axios.create({
    baseURL: process.env.REACT_APP_API
});

export const useApi = () =>({
    validateToken: async (token: string) => {
        const response = await api.post('/validate-token', { token });
        return response.data;
    },

    singin: async (username: string, password: string) => {
        const response = await api.post('/login', { username, password });
        return response.data;
    },

    singout: async () => {
        const response = await api.post('/singout');
        return response.data;
    }
});