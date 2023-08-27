import axios from 'axios'

const API = axios.create({
    baseURL: 'http://localhost:5194/api/',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export default API