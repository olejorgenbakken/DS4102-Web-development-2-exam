<template>
  <section class="admin padding">
    <TheHeader class="header"></TheHeader>
    <Greeting class="greeting" :firstName="user.firstName"></Greeting>
    <section class="menu">
      <header>
        <h3>Meny</h3>
      </header>
      <EditableDishList></EditableDishList>
    </section>

    <AddNewDish class="add-dish"></AddNewDish>
    <AddAdmin class="add-admin"></AddAdmin>
  </section>
</template>

<script>
import TheHeader from "../components/TheHeader.vue";
import Greeting from "../components/admin/Greeting.vue";
import EditableDishList from "../components/admin/EditableDishList.vue";
import AddNewDish from "../components/admin/AddNewDish.vue";
import AddAdmin from "../components/admin/AddAdmin.vue";

export default {
  name: "AdminHome",
  components: {
    TheHeader,
    Greeting,
    EditableDishList,
    AddNewDish,
    AddAdmin
  },
  data() {
    return {
      user: JSON.parse(sessionStorage.getItem("user"))
    };
  },
  created() {
    if (sessionStorage.getItem("user") == null) {
      this.$router.push({ name: "Login" });
    }
  }
};
</script>

<style scoped>
.admin {
  display: grid;
  grid-template-columns: repeat(6, 1fr);
  grid-template-rows: 70px repeat(4, auto);
  grid-template-areas:
    "header header header header header header"
    "greeting greeting greeting greeting greeting greeting"
    "menu menu menu menu menu menu"
    "dish dish dish dish dish dish"
    "user user user user user user";
  gap: 40px;
  width: 100%;
  max-width: 1300px;
  margin: 0 auto;
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

.greeting {
  margin: 0 auto;
  width: 100%;
  max-width: 800px;
  grid-area: greeting;
}

.menu {
  grid-area: menu;
  background: #ffffff;
  padding-top: 40px;
}

.menu header {
  text-align: center;
  padding-bottom: 20px;
}

.add-dish {
  grid-area: dish;
}

.add-user {
  grid-area: user;
}

@media only screen and (min-width: 800px) {
  .admin {
    grid-template-rows: 100px repeat(3, auto);
    grid-template-areas:
      "header header header header header header"
      "greeting greeting greeting greeting greeting greeting"
      "menu menu menu menu menu menu"
      "dish dish dish user user user";
  }

  .menu {
    box-shadow: inset 5px 5px 48px #f5f5f5, inset -5px -5px 48px #ffffff;
  }

  .menu {
    padding: 40px;
  }
}
</style>