import { createApp } from 'vue';
import PrimeVue from 'primevue/config';
import 'primevue/resources/themes/lara-light-blue/theme.css';
import 'primeicons/primeicons.css';
import App from './App.vue';
import router from './router';
import { createPinia } from 'pinia';

const app = createApp(App);
app.use(PrimeVue);
app.use(router);
app.use(createPinia());
app.mount('#app');
