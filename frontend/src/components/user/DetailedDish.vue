<template>
  <article :id="id" class="detailed card">
    <figure class="photo">
      <img :src="`https://localhost:5001/images/${photo}`" />
    </figure>
    <section class="info">
      <section class="name">
        <label>{{type}}</label>
        <h2>{{name}}</h2>
      </section>
      <section class="price">
        <label>Pris</label>
        <h3>{{price}} kr</h3>
      </section>
      <section class="desc">
        <label>Beskrivelse</label>
        <p>{{description}}</p>
      </section>
      <section class="ingredients">
        <label>Ingredienser</label>
        <p v-for="ingredient in ingredients" :key="ingredient">{{ingredient}}</p>
      </section>
      <BuyButton :id="id" class="buy"></BuyButton>
    </section>
  </article>
</template>

<script>
import BuyButton from "./BuyButton";
export default {
  name: "DetailedDish",
  props: {
    name: String,
    id: Number,
    type: String,
    ingredients: Array,
    description: String,
    photo: String,
    price: Number
  },
  components: {
    BuyButton
  }
};
</script>

<style scoped>
.detailed {
  display: flex;
  flex-direction: column;
  height: 80vh;
}

.photo {
  width: 100%;
  height: 400px;
}

.info {
  width: 100%;
  max-width: 450px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  padding: 20px;
}

.name,
.price,
.desc,
.ingredients {
  margin-bottom: 15px;
}

@media only screen and (min-width: 900px) {
  .photo {
    width: 500px;
    height: 100%;
  }

  .detailed {
    flex-direction: row;
  }

  .info {
    padding-left: 40px;
    margin: unset;
  }
}
</style>