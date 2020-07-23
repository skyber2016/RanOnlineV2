import axios from "axios";

var instance = axios;
instance.interceptors.request.use(
  function (config) {
    // Do something before request is sent
    const token = window.localStorage.getItem("token");
    if (token) {
      config.headers.common["Authorization"] = token;
    }
    return config;
  },
  function (error) {
    // Do something with request error
    return Promise.reject(error);
  }
);

// Add a response interceptor
instance.interceptors.response.use(
  function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data

    return response.data;
  },
  function (error) {
    if (error.response.status === 400) {
      return Promise.reject(error.response.data);
    }
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    return Promise.reject(error);
  }
);
export const http = instance;
