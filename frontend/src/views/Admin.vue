<template>
  <section class="admin padding">
    <TheHeader class="header padding"></TheHeader>
    <ColorPicker class="color-picker"></ColorPicker>
    <Greeting class="greeting" :firstName="user.firstName"></Greeting>
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
import TheHeader from "../components/TheHeader.vue";
import ColorPicker from "../components/admin/ColorPicker.vue";
import Greeting from "../components/admin/Greeting.vue";
import Search from "../components/Search";
import EditableDishList from "../components/admin/EditableDishList.vue";
import AddNewDish from "../components/admin/AddNewDish.vue";
import AddAdmin from "../components/admin/AddAdmin.vue";

export default {
  name: "AdminHome",
  components: {
    TheHeader,
    Greeting,
    ColorPicker,
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
          let adminDb = `https://localhost:5001/api/admins/id/${this.user.id}`;
          axios.get(adminDb).then(response => {
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
    const webAPIUrl = `https://localhost:5001/api/dishes/`;
    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  },
  methods: {
    search() {
      const webAPIUrl = `https://localhost:5001/api/dishes/`;
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
  grid-template-columns: repeat(12, 1fr);
  grid-template-rows: 70px repeat(5, auto);
  grid-template-areas:
    "header header header header header header header header header header header header"
    "greeting greeting greeting greeting greeting greeting greeting a a a a a"
    "color color color color color color e e e e e e"
    "menu menu menu menu menu menu menu menu menu menu menu menu"
    "dish dish dish dish dish dish dish dish dish dish dish dish"
    "admin admin admin admin admin admin admin admin admin admin admin admin";
  gap: 40px;
  width: 100%;
  max-width: 1300px;
  margin: 0 auto;
  padding-bottom: 60px;
}

.header {
  grid-area: header;
}

.greeting,
.add-dish,
.menu {
  width: 100%;
  margin: 0 auto;
  border-radius: 20px;
}

.color-picker {
  grid-area: color;
}

.greeting {
  margin: 0 auto;
  width: 100%;
  max-width: 800px;
  grid-area: greeting;
}

.menu {
  grid-area: menu;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

.menu header {
  text-align: center;
}

.add-dish {
  grid-area: dish;
}

.add-user {
  grid-area: admin;
}

@media only screen and (min-width: 600px) {
  .admin {
    grid-template-rows: 100px repeat(3, auto);
    grid-template-areas:
      "header header header header header header header header header header header header"
      "greeting greeting greeting greeting greeting color color color color color e e"
      "menu menu menu menu menu menu menu menu menu menu menu menu"
      "dish dish dish dish dish dish admin admin admin admin admin admin";
    gap: 60px 40px;
  }
}

@media only screen and (min-width: 900px) {
  .admin {
    grid-template-rows: 100px repeat(3, auto);
    grid-template-areas:
      "header header header header header header header header header header header header"
      "greeting greeting greeting greeting color color color e e e e e"
      "menu menu menu menu menu menu menu menu menu menu menu menu"
      "dish dish dish dish dish dish admin admin admin admin admin admin";
    gap: 60px 40px;
  }

  .menu {
    padding: 60px 40px;
    background: #ffffff;
    box-shadow: inset 10px 10px 20px #e3e3e3, inset -10px -10px 20px #ffffff;
  }
}

@media only screen and (min-width: 1200px) {
  .admin {
    grid-template-rows: 100px repeat(3, auto);
    grid-template-areas:
      "header header header header header header header header header header header header"
      "greeting greeting greeting color color e e e e e e e"
      "menu menu menu menu menu menu menu menu menu menu menu menu"
      "dish dish dish dish dish dish admin admin admin admin admin admin";
    gap: 60px 40px;
  }
}
</style>