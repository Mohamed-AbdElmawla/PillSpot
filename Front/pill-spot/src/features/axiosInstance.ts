import axios from 'axios';

let csrfToken: string | null = null;
let csrfPromise: Promise<string> | null = null;

const fetchCsrfToken = async (): Promise<string> => {
    try {
        const response = await axios.get(import.meta.env.VITE_CSRF, {
            withCredentials: true
        });
        const token = response.data.csrfToken || response.data;
        console.log('Fetched CSRF token:', token);
        csrfToken = token;
        return token;
    } catch (error) {
        console.error('Failed to fetch CSRF token:', error);
        throw error;
    }
};

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7298/',
    withCredentials: true,
});

// Async-safe interceptor that fetches CSRF token once
axiosInstance.interceptors.request.use(async (config) => {
    if (!csrfToken) {
        if (!csrfPromise) {
            csrfPromise = fetchCsrfToken();
        }
        try {
            await csrfPromise;
        } catch (e) {
            console.error('CSRF fetch failed, request may proceed without token.');
        }
    }

    if (csrfToken) {
        config.headers['X-CSRF-Token'] = csrfToken;
        console.log('CSRF token added to request:', csrfToken);
    }

    return config;
}, (error) => {
    return Promise.reject(error);
});

export default axiosInstance;
