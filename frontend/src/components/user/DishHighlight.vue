<template>
  <section
    class="dish-hero"
    :style="'background-image: url(https:localhost:5001/images/' + photo + ')'"
    :dish="id"
  >
    <section class="overlay">
      <section class="content">
        <h2 class="title">
          {{name}}
          <small>fra {{price}} kr</small>
        </h2>

        <p>{{description}}</p>

        <section class="links">
          <router-link :to="'dish/' + id" class="more-button">
            <button>Les mer</button>
          </router-link>
          <button @click="addToCart">Kjøp</button>
        </section>
      </section>
    </section>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "DishHighlight",
  props: {
    id: Number,
    photo: String,
    name: String,
    price: Number,
    description: String
  },
  methods: {
    addToCart() {
      let webAPIUrl = "https://localhost:5001/api/dishes/";

      axios.get(webAPIUrl).then(response => {
        response.data.forEach(dish => {
          if (dish.id == this.$el.getAttribute("dish")) {
            if (localStorage.getItem("order") == null) {
              let order = [dish];
              localStorage.setItem("order", JSON.stringify(order));
            } else {
              let order = JSON.parse(localStorage.getItem("order"));
              order.push(dish);
              localStorage.setItem("order", JSON.stringify(order));
            }
          }
        });
      });
    }
  }
};
</script>

<style scoped>
.dish-hero {
  height: 80vh;
  min-height: 400px;
  width: 100%;
  max-width: 1250px;
  margin: 0 auto 20px auto;
  background-size: cover;
  background-position: center center;
  display: flex;
  align-items: flex-end;
  position: relative;
}

.overlay {
  width: 100%;
  clip-path: polygon(0 0, 100% 10%, 100% 100%, 0% 100%);
  padding: 30px;
  background: var(--color);
}

.content {
  color: var(--black);
  display: grid;
  gap: 10px;
}

.content h2,
.content button {
  font-family: var(--subheading);
}

.content h2 {
  font-size: 2em;
  font-weight: 700;
}

.content h2 small {
  font-weight: 400;
  font-size: 0.8em;
  margin-left: 5px;
}

.links {
  display: grid;
  grid-template-columns: repeat(2, max-content);
  gap: 15px;
}

.content button {
  background: #fff;
  color: var(--black);
  width: 100%;
  max-width: 150px;
  padding: 10px 30px;
  font-weight: 700;
  border-radius: 30px;
}

@media only screen and (min-width: 700px) {
  .dish-hero {
    height: 75vh;
    min-height: 500px;
  }
  .overlay {
    position: relative;
    width: 60%;
    height: 100%;
    clip-path: polygon(0 0, 90% 0, 100% 100%, 0% 100%);
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .title {
    width: 95%;
  }

  .content button {
    margin-top: 20px;
  }
}
</style>