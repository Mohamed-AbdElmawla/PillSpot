import axios from 'axios';

let csrfPromise: Promise<string> | null = null;

const fetchCsrfToken = async (): Promise<string> => {
    try {
        const response = await axios.get(import.meta.env.BASE_URL + import.meta.env.VITE_CSRF, {
            withCredentials: true
        });
        const token = response.data.csrfToken || response.data;
        console.log('Fetched CSRF token:', token);
        return token;
    } catch (error) {
        console.error('Failed to fetch CSRF token:', error);
        throw error;
    }
};

const axiosInstance = axios.create({
    baseURL: import.meta.env.VITE_BASE_URL,
    withCredentials: true,
});

axiosInstance.interceptors.request.use(async (config) => {
    // Always fetch a new CSRF token before each request
    if (!csrfPromise) {
        csrfPromise = fetchCsrfToken();
    }
    
    try {
        const csrfToken = await csrfPromise;
        config.headers['X-CSRF-Token'] = csrfToken;
        console.log('CSRF token added to request:', csrfToken);
        // Reset the promise so next request will fetch a new token
        csrfPromise = null;
    } catch (error) {
        console.error('CSRF fetch failed, request may proceed without token:', error);
        // Reset the promise on error so we can retry
        csrfPromise = null;
    }

    return config;
}, (error) => {
    return Promise.reject(error);
});

export default axiosInstance;
