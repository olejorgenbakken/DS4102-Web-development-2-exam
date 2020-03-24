import Vue from 'vue'
import VueRouter from 'vue-router'
import User from "../views/User.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'User',
    component: User
  },
  {
    path: '/admin',
    name: 'Admin',
    component: () => import(/* webpackChunkName: 'Administration' */ '../views/Admin.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
