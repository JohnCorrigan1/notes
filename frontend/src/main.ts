import { createApp } from 'vue'
import { clerkPlugin } from 'vue-clerk'
import { dark } from '@clerk/themes'
import './assets/base.css'
import App from './App.vue'
import router from './router/index.js'
import hljsVuePlugin from '@highlightjs/vue-plugin'

const app = createApp(App)
app.use(router)
app.use(hljsVuePlugin)
app.use(clerkPlugin, {
  publishableKey: import.meta.env.VITE_CLERK_PUBLISHABLE_KEY,
  appearance: dark
})

app.mount('#app')
