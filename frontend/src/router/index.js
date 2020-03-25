import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from "../views/user/Home.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Frontpage',
    component: Home
  },
  {
    path: '/admin/:id',
    name: 'admin',
    component: () => import(/* webpackChunkName: 'Administration' */ '../views/admin/Admin.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
