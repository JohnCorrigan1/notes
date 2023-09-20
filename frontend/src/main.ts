import { createApp } from 'vue'
import './assets/base.css'
import App from './App.vue'
import router from './router'
import hljsVuePlugin from '@highlightjs/vue-plugin'

const app = createApp(App)
app.use(router)
app.use(hljsVuePlugin)

app.mount('#app')
