import Vue from 'vue'
import VueRouter from 'vue-router'
import Homepage from "../views/Homepage.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    component: Homepage,
    name: "Homepage",
    query: "?=dishTerm?=dishType",
  },
  {
    path: "/login",
    name: "Login",
    component: () => import(/* webpackChunkName: 'Login' */ '../views/Login'),
  },
  {
    path: "/account",
    name: "Account",
    component: () => import(/* webpackChunkName: 'Account' */ '../views/Account.vue')
  },
  {
    path: "/dish/:id",
    name: "Dish",
    component: () => import(/* webpackChunkName: 'Dish' */ '../views/Dish.vue')
  },
  {
    path: "/checkout",
    name: "Checkout",
    component: () => import(/* webpackChunkName: 'Checkout' */ '../views/Checkout.vue'),
    children: [
      {
        path: "order-empty",
        name: "NoItems",
        component: () => import(/* webpackChunkName: 'NoItems' */ '../components/checkout/NoItems.vue'),
      },
      {
        path: "overview",
        name: "Overview",
        component: () => import(/* webpackChunkName: 'OrderList' */ '../components/checkout/OrderList.vue'),
      },
      {
        path: "payment",
        name: "Payment",
        component: () => import(/* webpackChunkName: 'Payment' */ '../components/checkout/Payment.vue'),
      },
      {
        path: "complete",
        name: "FinishedOrder",
        component: () => import(/* webpackChunkName: 'FinishedOrder' */ '../components/checkout/FinishedOrder.vue'),
      },
    ]
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
