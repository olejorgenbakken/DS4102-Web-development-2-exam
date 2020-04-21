import Vue from 'vue'
import VueRouter from 'vue-router'
import Homepage from "../views/Homepage.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    component: Homepage,
    children: [
      {
        name: "Homepage",
        path: "/",
        query: "?=dishTerm?=dishType",
        component: () => import(/* webpackChunkName: 'DishList' */ '../components/user/DishList.vue')
      }
    ]
  },
  {
    path: "/dish",
    name: "Dish",
    children: [
      {
        path: ':id',
        name: 'Details',
        component: () => import(/* webpackChunkName: 'Dish' */ '../components/user/DetailedDish.vue')
      }
    ],
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
        component: () => import(/* webpackChunkName: 'EditableDishList' */ '../components/admin/EditableDishList.vue')
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
