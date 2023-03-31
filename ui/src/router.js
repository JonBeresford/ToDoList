import { createRouter, createWebHashHistory } from 'vue-router'
import ToDo from './views/ToDo.vue'

const router = createRouter({
  history: createWebHashHistory(),
  routes: [
    {
      path: '/',
      name: 'todo',
      component: ToDo
    }
  ]
})
export default router
