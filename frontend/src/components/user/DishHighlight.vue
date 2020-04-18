<template>
  <section
    class="dish-hero"
    :style="'background-image: url(https:localhost:5001/images/' + dish.photo + ')'"
    :dish="dish.id"
  >
    <section class="overlay">
      <section class="content">
        <h2 class="title">
          {{dish.name}}
          <small>fra {{dish.price}}kr</small>
        </h2>

        <p>{{dish.description}}</p>

        <section class="links">
          <router-link :to="{ name: 'Dish', params: {dishId: dish.id}}">
            <button class="more-button">Les mer</button>
          </router-link>
          <button @click="addToCart" class="buy-button">Kjøp</button>
        </section>
      </section>
    </section>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "DishHighlight",
  data() {
    return {
      dish: {}
    };
  },
  created() {
    let highlightedDish = "https://localhost:5001/api/dishes/highlighted/true";
    axios.get(highlightedDish).then(response => {
      this.dish = response.data;
    });
  },
  methods: {
    addToCart() {
      let id = this.$el.getAttribute("dish");
      let webAPIUrl = `https://localhost:5001/api/dishes/${id}`;

      axios.get(webAPIUrl).then(response => {
        if (localStorage.getItem("order") == null) {
          let order = [response.data];
          localStorage.setItem("order", JSON.stringify(order));
        } else {
          let order = JSON.parse(localStorage.getItem("order"));
          order.push(response.data);
          localStorage.setItem("order", JSON.stringify(order));
        }
      });
    }
  }
};
</script>

<style scoped>
.dish-hero {
  height: 100%;
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
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
  color: white;
  display: grid;
  gap: 10px;
}

.content h2,
.content button {
  font-family: var(--heading);
}

.content h2 {
  font-size: 2em;
  font-weight: 700;
}

.content h2 small {
  font-weight: 400;
  font-size: 0.7em;
  margin-left: 5px;
}

.links {
  display: grid;
  grid-template-columns: repeat(2, max-content);
  gap: 15px;
}

button {
  width: 100%;
  max-width: 150px;
  padding: 10px 30px;
  font-weight: 700;
  border-radius: 30px;
  transition: 0.2s ease-in-out;
}

.buy-button {
  background: white;
  color: var(--color);
}

.more-button {
  background: transparent;
  color: white;
  border: 3px solid white;
}

.more-button:hover {
  background: white;
  color: var(--color);
  border: 3px solid white;
}

@media only screen and (min-width: 700px) {
  .dish-hero {
    overflow: hidden;
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

  .content {
    padding-right: 20px;
  }

  .content button {
    margin-top: 20px;
  }
}

@media only screen and (min-width: 1200px) {
  .dish-hero {
    width: 95%;

    border-radius: 20px;
  }
}
</style>