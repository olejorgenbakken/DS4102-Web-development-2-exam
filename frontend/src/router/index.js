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
    children: [
      {
        path: "login",
        component: () => import(/* webpackChunkName: 'Login' */ '../views/Login'),
        children: [
          {
            name: "Login",
            path: "/",
            component: () => import(/* webpackChunkName: 'ExistingUser' */ '../components/login/LoginForm')
          }, {
            name: "CreateUser",
            path: "new",
            component: () => import(/* webpackChunkName: 'NewUser' */ '../components/login/CreateUserForm')
          }
        ]
      }
    ]
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
        name: "OrderList",
        component: () => import(/* webpackChunkName: 'OrderList' */ '../components/checkout/OrderList.vue'),
      },
      {
        path: "payment",
        name: "Payment",
        component: () => import(/* webpackChunkName: 'Payment' */ '../components/checkout/Payment.vue'),
      },
      {
        path: "finished",
        name: "OrderDone",
        component: () => import(/* webpackChunkName: 'OrderDone' */ '../components/checkout/NoItems.vue'),
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
