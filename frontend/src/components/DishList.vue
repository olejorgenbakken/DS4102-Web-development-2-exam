<template>
  <section class="lists">
    <section class="admin-list list" v-if="$route.name == 'Admin'">
      <EditableDishItem
        v-for="dish in dishesToShow"
        :key="dish.id"
        :id="dish.id"
        :name="dish.name"
        :price="dish.price"
        :photo="dish.photo"
        :description="dish.description"
        :highlighted="dish.highlighted"
        :type="dish.type"
        :ingredients="JSON.parse(dish.ingredients)"
      ></EditableDishItem>
    </section>
    <section v-else class="user-list" v-for="dishType in dishTypes" :key="dishType.id">
      <header class="list-header">
        <h3>{{dishType.name}}</h3>
      </header>
      <section class="user-dishes list">
        <DishItem
          v-for="dish in dishesToShow"
          :key="dish.id"
          :id="dish.id"
          :name="dish.name"
          :price="dish.price"
          :photo="dish.photo"
          :description="dish.description"
          :highlighted="dish.highlighted"
          :type="dish.type"
          :ingredients="JSON.parse(dish.ingredients)"
          :list="dishType.name"
        ></DishItem>
      </section>
    </section>
  </section>
</template>

<script>
import axios from "axios";
import DishItem from "./user/DishItem";
import EditableDishItem from "./admin/EditableDishItem";

export default {
  name: "DishList",
  components: {
    DishItem,
    EditableDishItem
  },
  data() {
    return {
      dishTypes: [],
      dishesToShow: [],
      allDishes: []
    };
  },
  beforeCreate() {
    let webAPIUrl = `https://localhost:5001/dishes/`;
    axios.get(webAPIUrl).then(response => {
      this.dishesToShow = response.data;
      this.allDishes = this.dishesToShow;
    });

    let dishtypesurl = "https://localhost:5001/dishtypes";
    axios.get(dishtypesurl).then(response => {
      this.dishTypes = response.data;
    });
  },
  watch: {
    $route() {
      let matchingDishes = [];
      if (
        this.$route.query.dish != undefined &&
        this.$route.query.type != undefined
      ) {
        this.allDishes.forEach(dish => {
          if (
            (dish.name
              .toLowerCase()
              .includes(this.$route.query.dish.toLowerCase()) ||
              dish.description
                .toLowerCase()
                .includes(this.$route.query.dish.toLowerCase())) &&
            dish.type
              .toLowerCase()
              .includes(this.$route.query.type.toLowerCase())
          ) {
            matchingDishes.push(dish);
          }
        });
        this.dishesToShow = matchingDishes;
      } else if (this.$route.query.dish != undefined) {
        this.allDishes.forEach(dish => {
          if (
            dish.name
              .toLowerCase()
              .includes(this.$route.query.dish.toLowerCase()) ||
            dish.description
              .toLowerCase()
              .includes(this.$route.query.dish.toLowerCase())
          ) {
            matchingDishes.push(dish);
          }
        });
        this.dishesToShow = matchingDishes;
      } else if (this.$route.query.type != undefined) {
        this.allDishes.forEach(dish => {
          if (
            dish.type
              .toLowerCase()
              .includes(this.$route.query.type.toLowerCase())
          ) {
            matchingDishes.push(dish);
          }
        });
        this.dishesToShow = matchingDishes;
      } else {
        this.dishesToShow = this.allDishes;
      }
    }
  }
};
</script>

<style scoped>
.list-header {
  padding-bottom: 10px;
}

.list {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  width: 100%;
}

.user-dishes {
  grid-template-areas:
    "header"
    "menu";
}

.user-dishes header {
  grid-area: header;
}

@media only screen and (min-width: 500px) {
  .list {
    grid-template-columns: repeat(2, 1fr);
  }

  .user-dishes {
    grid-template-areas:
      "header header"
      "menu menu";
  }
}

@media only screen and (min-width: 800px) {
  .list {
    grid-template-columns: repeat(3, 1fr);
  }

  .user-dishes {
    grid-template-areas:
      "header header header"
      "menu menu menu";
  }
}

@media only screen and (min-width: 1000px) {
  .list {
    grid-template-columns: repeat(4, 1fr);
  }

  .user-dishes {
    grid-template-areas:
      "header header header header"
      "menu menu menu menu";
  }
}
</style>