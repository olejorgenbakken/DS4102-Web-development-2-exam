<template>
  <section class="admin padding">
    <Greeting class="greet" :firstName="user.firstName"></Greeting>
    <Settings class="settings"></Settings>
    <AddAdmin class="user"></AddAdmin>
    <AddNewDish class="dish"></AddNewDish>
    <section class="menu card">
      <header>
        <h2>Meny</h2>
      </header>
      <Search></Search>
      <router-view>
        <EditableDishList :dishes="dishes"></EditableDishList>
      </router-view>
    </section>
  </section>
</template>

<script>
import axios from "axios";
import Settings from "../components/admin/Settings.vue";
import Greeting from "../components/admin/Greeting.vue";
import Search from "../components/Search";
import EditableDishList from "../components/admin/EditableDishList.vue";
import AddNewDish from "../components/admin/AddNewDish.vue";
import AddAdmin from "../components/admin/AddAdmin.vue";

export default {
  name: "AdminHome",
  components: {
    Greeting,
    Settings,
    Search,
    EditableDishList,
    AddNewDish,
    AddAdmin
  },
  data() {
    return {
      user: {},
      dishes: []
    };
  },
  beforeMount() {
    if (document.cookie) {
      let cookies = document.cookie.split(";");
      if (cookies.length > 1) {
        return "";
      } else {
        let loginCookie = cookies[0].split("=");
        if (loginCookie[0] == "login") {
          this.user.id = loginCookie[1];
          let userDB = `https://localhost:5001/users/${this.user.id}`;
          axios.get(userDB).then(response => {
            this.user = response.data;
          });
        } else {
          this.$router.push("/login");
        }
      }
    } else {
      this.$router.push("/login");
    }
  }
};
</script>

<style scoped>
.admin {
  display: grid;
  gap: 30px;
  width: 100%;
  max-width: 1100px;
  margin: 0 auto;
  padding: 60px 20px;
  grid-template-columns: repeat(6, 1fr);
  grid-template-areas:
    "greet greet greet greet greet greet"
    "settings settings settings settings settings settings"
    "user user user user user user"
    "dish dish dish dish dish dish"
    "menu menu menu menu menu menu";
}

.greet {
  grid-area: greet;
}

.settings {
  grid-area: settings;
}

.dish {
  grid-area: dish;
}

.user {
  grid-area: user;
}

.menu {
  grid-area: menu;
  display: grid;
  grid-template-rows: repeat(3, auto);
  gap: 30px;
}

@media only screen and (min-width: 500px) {
  .admin {
    grid-template-areas:
      "greet greet greet settings settings settings"
      "user user user user user user"
      "dish dish dish dish dish dish"
      "menu menu menu menu menu menu";
  }
}

@media only screen and (min-width: 700px) {
  .admin {
    grid-template-areas:
      "greet greet greet settings settings settings"
      "user user user dish dish dish"
      "menu menu menu menu menu menu";
  }
}

@media only screen and (min-width: 900px) {
  .admin {
    grid-template-areas:
      "greet greet dish dish dish dish"
      "settings settings dish dish dish dish"
      "user user dish dish dish dish"
      "menu menu menu menu menu menu";
  }
}
</style>