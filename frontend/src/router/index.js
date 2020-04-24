import Vue from 'vue'
import VueRouter from 'vue-router'
import Homepage from "../views/Homepage.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    component: Homepage,
    props: { default: true, sidebar: false },
    children: [
      {
        name: "Homepage",
        path: "/",
        query: "?=dishTerm?=dishType",
        component: () => import(/* webpackChunkName: 'DishList' */ '../components/DishList.vue')
      }
    ]
  },
  {
    path: "/dish/:id",
    name: "Dish",
    component: () => import(/* webpackChunkName: 'Dish' */ '../views/Dish.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import(/* webpackChunkName: 'Login' */ '../views/Login.vue')
  },
  {
    path: '/admin',
    component: () => import(/* webpackChunkName: 'Admin' */ '../views/Admin.vue'),
    children: [
      {
        name: "Admin",
        path: "/",
        query: "?=dishTerm?=dishType",
        component: () => import(/* webpackChunkName: 'DishList' */ '../components/DishList.vue')
      }
    ]
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
