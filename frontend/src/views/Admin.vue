<template>
  <section class="admin padding">
    <Greeting class="greet" :firstName="user.firstName"></Greeting>
    <Settings class="settings"></Settings>
    <AddAdmin class="user"></AddAdmin>
    <AddNewDish class="add-dish"></AddNewDish>
    <section class="menu">
      <header>
        <h2>Meny</h2>
      </header>
      <Search></Search>
      <keep-alive>
        <router-view>
          <DishList :dishes="dishes"></DishList>
        </router-view>
      </keep-alive>
    </section>
  </section>
</template>

<script>
import axios from "axios";
import Settings from "../components/admin/Settings.vue";
import Greeting from "../components/admin/Greeting.vue";
import Search from "../components/Search";
import DishList from "../components/DishList";
import AddNewDish from "../components/admin/AddNewDish.vue";
import AddAdmin from "../components/admin/AddAdmin.vue";

export default {
  name: "AdminHome",
  components: {
    Greeting,
    Settings,
    Search,
    DishList,
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
</style>