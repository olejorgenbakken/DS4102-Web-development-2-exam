<template>
  <section class="admin">
    <Greeting class="name" :firstName="user.firstName" :lastName="user.lastName"></Greeting>
    <Settings class="settings"></Settings>
    <AddNewDish class="add-dish"></AddNewDish>
    <section class="menu">
      <header class="menu-header">
        <h2>Meny</h2>
        <Search></Search>
      </header>
      <keep-alive>
        <router-view>
          <DishList :dishes="dishes"></DishList>
        </router-view>
      </keep-alive>
    </section>
  </section>
</template>

<script>
import { store } from "../store.js";
import Settings from "../components/admin/Settings.vue";
import Greeting from "../components/admin/Greeting.vue";
import Search from "../components/Search";
import DishList from "../components/DishList";
import AddNewDish from "../components/admin/AddNewDish.vue";

export default {
  name: "AdminHome",
  components: {
    Greeting,
    Settings,
    Search,
    DishList,
    AddNewDish
  },
  data() {
    return {
      loggedIn: store.state.loggedIn,
      isAdmin: store.state.isAdmin,
      user: store.state.user,
      dishes: []
    };
  },
  created() {
    if (this.loggedIn) {
      if (!this.isAdmin) {
        this.$router.push({ name: "Homepage" });
      }
    } else {
      this.$router.push({ name: "Login" });
    }
  }
};
</script>

<style scoped>
.admin {
  padding: 0 20px 20px 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 30px;
  width: 100%;
  max-width: 1100px;
  margin: 0 auto;
}

.menu-header {
  display: flex;
  flex-direction: column;
  padding-bottom: 20px;
}

.menu-header h2 {
  margin-bottom: 20px;
}

@media only screen and (min-width: 500px) {
  .admin {
    grid-template-columns: repeat(5, 1fr);
    grid-template-areas:
      "name name name settings settings"
      "user user user user user"
      "add-dish add-dish add-dish add-dish add-dish"
      "menu menu menu menu menu ";
  }

  .name {
    align-self: flex-start;
    grid-area: name;
  }

  .settings {
    align-self: flex-start;
    grid-area: settings;
  }

  .user {
    align-self: flex-start;
    grid-area: user;
  }

  .add-dish {
    align-self: flex-start;
    grid-area: add-dish;
  }

  .menu {
    align-self: flex-start;
    grid-area: menu;
  }
}

@media only screen and (min-width: 800px) {
  .admin {
    grid-template-columns: repeat(2, 1fr);
    grid-template-areas:
      "name add-dish"
      "settings add-dish"
      "user add-dish"
      "empty add-dish"
      "menu menu";
  }
}

@media only screen and (min-width: 800px) {
  .menu-header {
    display: flex;
    flex-direction: column;
    padding-bottom: 30px;
  }
}
</style>