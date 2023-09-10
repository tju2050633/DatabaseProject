import axios from 'axios';

const API = axios.create({
    baseURL: 'http://39.106.47.60:5194',
    timeout: 3000,
    async: true,
    crossDomain: true,
})

export function postFeedback(user_id, selectedRadio, topic, content, files, email) {
    let feedback = {
        accountId: user_id,
        selectedRadio: selectedRadio, 
        topic: topic,
        content: content,
        email: email
    }

    const formData = new FormData(); 
    formData.append('feedbackJson', JSON.stringify(feedback));
  
    const response = API.post('/feedback/post', formData);
    return response.data;
}