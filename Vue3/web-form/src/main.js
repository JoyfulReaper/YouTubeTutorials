import { createApp } from 'vue'
import App from './App.vue'

const app = createApp(App)
app.provide('baseUrl', 'https://localhost:7281/api')

app.mount('#app')