<template>
  <article class="dish card">
    <section class="photo">
      <figure class="figure">
        <input type="file" name="upload-img" id="uploaded-pic" @change="previewPic" />
        <img :src="`https:/localhost:5001/images/${photo}`" />
      </figure>
    </section>
    <section class="info">
      <section class="name">
        <label>Navn</label>
        <input v-model="name" type="text" class="title" placeholder="Tittel" />
      </section>
      <section class="price">
        <label>Pris (kr)</label>
        <input type="number" v-model="price" />
      </section>
      <section class="type">
        <label>Type</label>
        <select v-model="type">
          <option v-for="type in dishTypes" :value="type.name" :key="type.id">{{type.name}}</option>
        </select>
      </section>
      <section class="ingredients">
        <section class="all-ingredients">
          <label>Ingredienser</label>
          <select multiple v-model="ingredients">
            <option
              v-for="ingredient in allIngredients"
              :key="ingredient"
              :value="ingredient"
            >{{ingredient}}</option>
          </select>
        </section>
        <section class="selected-ingredients" v-if="ingredients.length > 0">
          <label>Valgte ingredienser:</label>
          <section class="list">
            <p
              class="ingredient"
              v-for="ingredient in ingredients"
              :key="ingredient"
              @click="removeIng"
            >{{ingredient}}</p>
          </section>
        </section>
      </section>
      <section class="highlighted">
        <label>Fremhevet</label>
        <section class="input-highlighted">
          <label class="input">
            <input type="radio" v-model="highlighted" :value="true" />
            <p>Ja</p>
          </label>
          <label class="input">
            <input type="radio" v-model="highlighted" :value="false" />
            <p>Nei</p>
          </label>
        </section>
      </section>
      <section class="desc">
        <label>Beskrivelse</label>
        <textarea v-model="description" />
      </section>
    </section>

    <section class="del">
      <button @click="deleteDish" class="del-btn">Slett</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "EditableDishItem",
  props: {
    name: String,
    id: Number,
    ingredients: Array,
    type: String,
    price: Number,
    photo: String,
    description: String,
    highlighted: Boolean
  },
  data() {
    return {
      allIngredients: [],
      dishTypes: []
    };
  },
  created() {
    let ingredientsURL = `https://localhost:5001/ingredients`;
    axios.get(ingredientsURL).then(response => {
      response.data.forEach(ingredient => {
        this.allIngredients.push(ingredient.name);
      });
    });

    let dishTypes = `https://localhost:5001/dishtypes`;
    axios.get(dishTypes).then(response => {
      this.dishTypes = response.data;
    });
  },
  methods: {
    addIngredient() {
      console.log(this.allIngredients);
    },
    deleteDish() {
      let dishesURL = `https://localhost:5001/dishes/${this.id}`;
      axios.delete(dishesURL);
    },
    previewPic() {
      let input = this.$el.querySelector("#uploaded-pic");
      this.photo = input.files[0].name;
    },
    removeIng(e) {
      this.ingredients.forEach(ingredient => {
        if (ingredient == e.target.innerText) {
          const index = this.ingredients.indexOf(ingredient);
          if (index > -1) {
            this.ingredients.splice(index, 1);
          }
          e.target.remove();
        }
      });
    }
  },
  updated() {
    this.newDish = {
      name: this.name,
      id: this.id,
      ingredients: this.ingredients,
      type: this.type,
      price: this.price,
      photo: this.photo,
      description: this.description,
      highlighted: this.highlighted
    };
    this.newDish.price = parseInt(this.newDish.price);
    this.newDish.ingredients = JSON.stringify(this.newDish.ingredients);
    let input = this.$el.querySelector("#uploaded-pic");

    let dishUploadURL = `https://localhost:5001/dishes/upload`;

    if (input.files[0] != undefined && input.files[0].name == this.photo) {
      this.newDish.photo = input.files[0].name;
    } else if (
      input.files[0] != undefined &&
      input.files[0].name != this.newDish.photo
    ) {
      let imageData = new FormData();
      imageData.append("file", input.files[0]);
      axios
        .post(dishUploadURL, imageData, {
          headers: { "Content-type": "multiplart/form-data" }
        })
        .then(() => {
          this.newDish.photo = input.files[0].name;
          let dishURL = `https://localhost:5001/dishes/`;
          axios.put(dishURL, this.newDish);
        });
    } else {
      let dishURL = `https://localhost:5001/dishes/`;
      axios.put(dishURL, this.newDish);
    }
  }
};
</script>

<style scoped>
</style>