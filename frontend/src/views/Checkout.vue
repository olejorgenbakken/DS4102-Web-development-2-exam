<template>
  <section class="checkout">
    <header class="checkout-header">
      <h2>Handlekurv</h2>
    </header>
    <router-view></router-view>
    <section class="card order-total">
      <h2>Kasse</h2>
      <section class="info">
        <aside class="info-icon">
          <svg
            aria-hidden="true"
            focusable="false"
            data-prefix="fas"
            data-icon="tag"
            role="img"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 512 512"
            class="svg-inline--fa fa-tag fa-w-16 fa-3x"
          >
            <path
              d="M0 252.118V48C0 21.49 21.49 0 48 0h204.118a48 48 0 0 1 33.941 14.059l211.882 211.882c18.745 18.745 18.745 49.137 0 67.882L293.823 497.941c-18.745 18.745-49.137 18.745-67.882 0L14.059 286.059A48 48 0 0 1 0 252.118zM112 64c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48z"
            />
          </svg>
        </aside>
        <section class="info-text">
          <label class="currency">Total</label>
          <h3>{{total}}kr</h3>
        </section>
      </section>
      <router-link v-if="loggedIn" :to="{name: 'Payment'}">
        <button>Betal</button>
      </router-link>
      <Login v-else></Login>
    </section>
  </section>
</template>

<script>
import { store } from "../store.js";
import Login from "../components/login/LoginForm";

export default {
  name: "Checkout",
  components: {
    Login
  },
  data() {
    return {
      loggedIn: store.state.loggedIn,
      order: JSON.parse(localStorage.getItem("order")),
      total: store.total()
    };
  },
  created() {
    if (this.order) {
      this.$router.push({ name: "OrderList" });
    } else {
      this.$router.push({ name: "NoItems" });
    }
  }
};
</script>

<style scoped>
.checkout {
  width: 100%;
  max-width: 1000px;
  padding: 0 20px 40px 20px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

.checkout-header {
  height: max-content;
}

.order-total {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  padding: 20px;
}

.info {
  display: grid;
  grid-template-columns: 40px 1fr;
  gap: 10px;
}

.info-icon {
  height: 40px;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}

.info-icon svg {
  color: var(--text);
  fill: var(--text);
  height: 25px;
  width: 25px;
}

.info p {
  font-weight: 700;
}

@media screen and (min-width: 800px) {
  .checkout {
    grid-template-columns: 1fr 400px;
    align-items: flex-start;
  }

  .checkout-header {
    grid-column: 1 / span 2;
  }
}
</style>