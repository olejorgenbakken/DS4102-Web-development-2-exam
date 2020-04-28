<template>
  <section class="admin">
    <Greeting class="name" :firstName="user.firstName" :lastName="user.lastName"></Greeting>
    <Settings class="settings"></Settings>
    <Ingredients class="ingredients"></Ingredients>
    <DishTypesAdmin class="dish-types"></DishTypesAdmin>
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
import axios from "axios";
import Greeting from "../components/admin/Greeting.vue";
import Settings from "../components/admin/Settings.vue";
import Ingredients from "../components/admin/Ingredients.vue";
import DishTypesAdmin from "../components/admin/DishTypes.vue";
import Search from "../components/Search";
import DishList from "../components/DishList";
import AddNewDish from "../components/admin/AddNewDish.vue";

export default {
  name: "AdminHome",
  components: {
    Greeting,
    Settings,
    Ingredients,
    DishTypesAdmin,
    Search,
    DishList,
    AddNewDish
  },
  data() {
    return {
      user: null,
      dishes: []
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

@media only screen and (min-width: 890px) {
  .admin {
    grid-template-columns: repeat(2, 1fr);
    grid-template-areas:
      "settings name"
      "ingredients add-dish"
      "dish-types add-dish"
      "dish-types add-dish"
      "menu menu";
  }

  .name,
  .settings,
  .add-dish,
  .ingredients,
  .dish-types,
  .menu {
    align-self: flex-start;
  }

  .name {
    grid-area: name;
  }

  .settings {
    grid-area: settings;
  }

  .dish-types {
    grid-area: dish-types;
  }

  .ingredients {
    grid-area: ingredients;
  }

  .add-dish {
    grid-area: add-dish;
  }

  .menu {
    grid-area: menu;
  }

  .menu-header {
    display: flex;
    flex-direction: column;
    padding-bottom: 30px;
  }
}
</style>