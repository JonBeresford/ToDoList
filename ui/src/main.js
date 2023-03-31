import '@babel/polyfill'
import { createApp } from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import router from './router'
import store from './store'
import './registerServiceWorker'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import * as lists from 'vuetify/components/VList'

const vuetify = createVuetify({
  components,
  directives,
  lists
})

const app = createApp(App)

app.use(vuetify)
app.use(store)
app.use(router)
app.mount('#app')
