<template>
  <article :id="id" class="detailed" :dish="id">
    <figure class="photo">
      <img :src="`https://localhost:5001/images/${photo}`" />
    </figure>
    <section class="info">
      <section class="title">
        <label>Navn</label>
        <h2>{{name}}</h2>
      </section>
      <section class="price">
        <label>Pris</label>
        <h3>{{price}} kr</h3>
      </section>
      <section>
        <label>Beskrivelse</label>
        <p>{{description}}</p>
      </section>
      <section>
        <label>Ingredienser</label>
        <p v-for="ingredient in ingredients" :key="ingredient">{{ingredient}}</p>
      </section>
      <button class="buy-button" @click="addToCart">Kjøp</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";
export default {
  name: "DetailedDish",
  data() {
    return {
      theDish: {}
    };
  },
  props: {
    name: String,
    id: Number,
    description: String,
    photo: String,
    price: Number,
    ingredients: String
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
.detailed {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 300px 1fr;
  grid-template-rows: 400px 1fr;
  grid-template-areas:
    "picture picture"
    "info info";
  gap: 10px 0;
}

.photo {
  grid-area: picture;
  overflow: hidden;
}

.photo img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.info {
  grid-area: info;
  width: 100%;
  max-width: 600px;
  margin: 0 auto;
  padding: 0 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px;
}

.buy-button {
  background: var(--color);
  color: white;
  width: 100%;
  max-width: 150px;
  padding: 10px;
  font-family: var(--heading);
  font-weight: 700;
  border-radius: 30px;
  transition: 0.3s ease-in-out;
}

@media only screen and (min-width: 800px) {
  .photo {
    border-radius: 20px;
  }
  .detailed {
    grid-template-areas:
      "picture info"
      "picture info";
    padding: 0 20px;
    gap: 0 10px;
  }

  .info {
    align-self: center;
    margin-left: 0;
  }
}
</style>