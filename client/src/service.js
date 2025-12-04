
import axios from 'axios';

// הגדרת כתובת בסיס לכל הבקשות
// שימוש בכתובת מ-ENV ואם לא קיים, נפילה לכתובת השרת בפרודקשן
axios.defaults.baseURL = process.env.REACT_APP_API_URL || 'https://todotasks-server.onrender.com';

// הוספת interceptor לתפיסת שגיאות מהשרת
axios.interceptors.response.use(
  // ✅ אם התגובה תקינה
  (response) => response,
  
  // ⚠️ אם יש שגיאה – נתפוס אותה כאן
  (error) => {
    console.error('⚠️ שגיאת Axios:', {
      url: error.config?.url,
      method: error.config?.method,
      status: error.response?.status,
      message: error.message,
      data: error.response?.data
    });
    // חשוב להחזיר את ההבטחה הדחויה כדי ש-Axios ידע שזו שגיאה אמיתית
    return Promise.reject(error);
  }
);

export default {
  // שליפת כל המשימות
  getTasks: async () => {
    const result = await axios.get('/items');
    return result.data;
  },

  // הוספת משימה חדשה
  addTask: async (name) => {
    console.log('addTask', name);
    const newTask = {
      name: name,
      isComplete: false,
    };

    const result = await axios.post('/items', newTask);
    return result.data;
  },

  // עדכון מצב השלמת משימה
  setCompleted: async (id, isComplete) => {
    console.log('setCompleted', { id, isComplete });

    const updatedTask = {
      isComplete: isComplete,
    };

    const result = await axios.put(`/items/${id}`, updatedTask);
    return result.data;
  },

  // מחיקת משימה
  deleteTask: async (id) => {
    console.log('deleteTask', id);
    const result = await axios.delete(`/items/${id}`);
    return result.data;
  }
};
