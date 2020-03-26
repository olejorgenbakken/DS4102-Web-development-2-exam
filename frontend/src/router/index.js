import Vue from 'vue'
import VueRouter from 'vue-router'
import UserHome from "../views/User.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Frontpage',
    component: UserHome
  },
  {
    path: '/admin/:id',
    name: 'admin',
    component: () => import(/* webpackChunkName: 'AdminHome' */ '../views/Admin.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
