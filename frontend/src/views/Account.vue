<template>
  <section class="account">
    <header class="account-header">
      <h2>Konto</h2>
    </header>
    <Greeting class="name" :firstName="user.firstName" :lastName="user.lastName"></Greeting>
  </section>
</template>

<script>
import axios from "axios";
import Greeting from "../components/admin/Greeting.vue";

export default {
  name: "Account",
  components: {
    Greeting
  },
  data() {
    return {
      orders: null,
      user: null
    };
  },
  created() {
    if (document.cookie) {
      let cookies = document.cookie.split(";");
      if (cookies.length > 1) {
        return "";
      } else {
        let loginCookie = cookies[0].split("=");
        if (loginCookie[0] == "login") {
          let userID = loginCookie[1];
          let userDB = `https://localhost:5001/users/id/${userID}`;
          axios.get(userDB).then(response => {
            this.user = response.data;
            let userEmail = response.data.email;
            let orderDB = `https://localhost:5001/orders/user/${userEmail}`;
            axios.get(orderDB).then(response => {
              this.orders = response.data;
            });
          });
        }
      }
    } else {
      this.$router.push({ name: "Homepage" });
    }
  }
};
</script>

<style scoped>
.account {
  padding: 0 20px 20px 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px 30px;
  width: 100%;
  max-width: 1100px;
  margin: 0 auto;
}

.account-header {
  display: flex;
  flex-direction: column;
}

@media only screen and (min-width: 890px) {
  .account {
    grid-template-columns: repeat(2, 1fr);
    grid-template-areas:
      "header header"
      "name e"
      "orders orders";
  }

  .name,
  .orders {
    align-self: flex-start;
  }

  .name {
    grid-area: name;
  }

  .orders {
    grid-area: orders;
  }
}
</style>