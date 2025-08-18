import {createApp} from 'vue'
import './style.css'
import App from './App.vue'
import {router} from "@/router";
import {createPinia} from "pinia";
import {Toaster} from "vue-sonner";

const pinia = createPinia();

createApp(App)
    .component('Toaster', Toaster)
    .use(router)
    .use(pinia)
    .mount('#app')
