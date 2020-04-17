import Vue from 'vue'
import VueRouter from 'vue-router'
import Homepage from "../views/Homepage.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Homepage',
    component: Homepage,
  },
  {
    path: "/dish/:dishId",
    name: "Dish",
    component: () => import(/* webpackChunkName: 'Dish' */ '../views/Dish.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import(/* webpackChunkName: 'Login' */ '../views/Login.vue')
  },
  {
    path: '/admin/:id',
    name: 'Admin',
    component: () => import(/* webpackChunkName: 'AdminHome' */ '../views/Admin.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
