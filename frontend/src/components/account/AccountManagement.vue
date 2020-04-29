<template>
  <article class="card change-account">
    <header>
      <h3>Endre konto</h3>
    </header>

    <section class="update">
      <label>Endre navn</label>
      <input type="text" v-model="user.firstName" placeholder="Endre fornavn" />
      <input type="text" v-model="user.lastName" placeholder="Endre etternavn" />
      <button @click="updateAccount">Endre</button>
    </section>

    <section class="delete">
      <label>Slett konto</label>
      <button class="del-btn" @click="deleteAccount">Slett</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "AccountManagement",
  data() {
    return {
      user: {}
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
          });
        }
      }
    }
  },
  methods: {
    updateAccount() {
      let updatedUser;
      let userToUpdate = `https://localhost:5001/users/id/${this.user.id}`;
      axios
        .get(userToUpdate)
        .then(response => {
          updatedUser = response.data;
          updatedUser.firstName = this.user.firstName;
          updatedUser.lastName = this.user.lastName;
        })
        .then(() => {
          let userDB = `https://localhost:5001/users/`;
          axios.put(userDB, updatedUser);
        });
    },
    deleteAccount() {
      let dishIngredientToDelete = `https://localhost:5001/users/${this.user.id}`;
      axios.delete(dishIngredientToDelete);
      document.cookie = "login" + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      this.$router.push({ name: "Homepage" });
    }
  }
};
</script>

<style scoped>
.change-account {
  align-self: flex-start;
  display: grid;
  grid-template-rows: 1fr;
  gap: 20px;
  padding: 20px;
}

.update {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 10px;
}

.update label {
  grid-column: span 3;
}
</style>