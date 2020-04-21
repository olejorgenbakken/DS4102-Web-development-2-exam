<template>
  <section class="admin padding">
    <Greeting class="greeting" :firstName="user.firstName"></Greeting>
    <Settings class="settings"></Settings>
    <section class="menu">
      <header>
        <h2>Meny</h2>
      </header>
      <Search v-model="searchTerm" @input="search"></Search>
      <EditableDishList :dishes="dishes"></EditableDishList>
    </section>

    <AddNewDish class="add-dish"></AddNewDish>
    <AddAdmin class="add-admin"></AddAdmin>
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
      searchTerm: undefined,
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
  },
  created() {
    const webAPIUrl = `https://localhost:5001/dishes/`;
    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  },
  methods: {
    search() {
      const webAPIUrl = `https://localhost:5001/dishes/`;
      axios.get(webAPIUrl).then(response => {
        let dishes = [];
        response.data.forEach(dish => {
          if (
            dish.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
            dish.type.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
            dish.description
              .toLowerCase()
              .includes(this.searchTerm.toLowerCase())
          ) {
            dishes.push(dish);
            this.dishes = dishes;
          } else {
            this.dishes = dishes;
          }
        });
      });
    }
  }
};
</script>

<style scoped>
.admin {
  display: grid;
  gap: 40px;
  width: 100%;
  max-width: 1300px;
  margin: 0 auto;
  padding: 60px 20px;
}
</style>