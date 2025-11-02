// import axios from 'axios';

// const apiUrl = "http://localhost:5281"

// export default {
//   getTasks: async () => {
//     const result = await axios.get(`${apiUrl}/items`)    
//     return result.data;
//   },

//   addTask: async(name)=>{
//     console.log('addTask', name)
//     //TODO
//     return {};
//   },

//   setCompleted: async(id, isComplete)=>{
//     console.log('setCompleted', {id, isComplete})
//     //TODO
//     return {};
//   },

//   deleteTask:async()=>{
//     console.log('deleteTask')
//   }
// };
// import axios from 'axios';

// const apiUrl = "http://localhost:5281"

// export default {
//   // פונקציה לשליפת כל המשימות
//   getTasks: async () => {
//     const result = await axios.get(`${apiUrl}/items`)    
//     return result.data;
//   },

//   // פונקציה להוספת משימה חדשה
//   addTask: async (name) => {
//     console.log('addTask', name);
//     const newTask = {
//       name: name,
//       isComplete: false, // ברירת המחדל היא משימה לא הושלמה
//     };
    
//     const result = await axios.post(`${apiUrl}/items`, newTask);
//     return result.data;
//   },

//   // פונקציה לעדכון מצב המשימה (השלמה/לא הושלמה)
//   setCompleted: async (id, isComplete) => {
//     console.log('setCompleted', { id, isComplete });

//     const updatedTask = {
//       isComplete: isComplete,
//     };

//     const result = await axios.put(`${apiUrl}/items/${id}`, updatedTask);
//     return result.data;
//   },

//   // פונקציה למחיקת משימה
//   deleteTask: async (id) => {
//     console.log('deleteTask', id);
//     const result = await axios.delete(`${apiUrl}/items/${id}`);
//     return result.data;
//   }
// };
// import axios from 'axios';

// // הגדרה גלובלית של כתובת הבסיס לכל הבקשות
// axios.defaults.baseURL = 'http://localhost:5281';

// export default {
//   // שליפת כל המשימות
//   getTasks: async () => {
//     const result = await axios.get('/items');
//     return result.data;
//   },

//   // הוספת משימה חדשה
//   addTask: async (name) => {
//     console.log('addTask', name);
//     const newTask = {
//       name: name,
//       isComplete: false,
//     };

//     const result = await axios.post('/items', newTask);
//     return result.data;
//   },

//   // עדכון מצב השלמת משימה
//   setCompleted: async (id, isComplete) => {
//     console.log('setCompleted', { id, isComplete });

//     const updatedTask = {
//       isComplete: isComplete,
//     };

//     const result = await axios.put(`/items/${id}`, updatedTask);
//     return result.data;
//   },

//   // מחיקת משימה
//   deleteTask: async (id) => {
//     console.log('deleteTask', id);
//     const result = await axios.delete(`/items/${id}`);
//     return result.data;
//   }
// };
import axios from 'axios';

// הגדרת כתובת בסיס לכל הבקשות
axios.defaults.baseURL = 'http://localhost:5281';

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
