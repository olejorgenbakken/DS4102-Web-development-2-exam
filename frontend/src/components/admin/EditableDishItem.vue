<template>
  <article class="dish card">
    <section class="photo">
      <figure class="figure">
        <input type="file" name="upload-img" id="uploaded-pic" />
        <img :src="`https:/localhost:5001/images/${dish.photo}`" />
      </figure>
    </section>

    <section class="name">
      <label>Navn</label>
      <input v-model="dish.name" />
    </section>
    <section class="desc">
      <label>Beskrivelse</label>
      <textarea v-model="dish.description" />
    </section>
    <section class="price">
      <label>Pris</label>
      <input type="number" v-model="dish.price" />
    </section>
    <section class="type">
      <label>Type</label>
      <select v-model="dish.type">
        <option v-for="type in dishTypes" :key="type">{{type}}</option>
      </select>
    </section>
    <section class="highlighted">
      <label>Fremhevet</label>
      <section class="input-highlighted">
        <label>
          <input type="radio" v-model="dish.highlighted" :value="true" />
          <p>Ja</p>
        </label>
        <label>
          <input type="radio" v-model="dish.highlighted" :value="false" />
          <p>Nei</p>
        </label>
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
  name: "DishItem",
  data() {
    return {
      dishTypes: ["Forrett", "Maki", "Sashimi", "Nigiri", "Vegetar", "Drikke"],
      dish: {}
    };
  },
  props: {
    id: Number
  },
  created() {
    let dish = `https://localhost:5001/api/dishes/${this.id}`;
    axios.get(dish).then(response => {
      this.dish = response.data;
    });
  },
  methods: {
    // Deletes a dish from the database using the div's "dish" value.
    deleteDish() {
      let dishesURL = `https://localhost:5001/api/dishes/${this.dish.id}`;
      axios.delete(dishesURL);
    }
  },
  updated() {
    this.dish.price = parseInt(this.dish.price);
    let input = this.$el.querySelector("#uploaded-pic");

    let dishUploadURL = `https://localhost:5001/api/dishes/upload`;

    if (input.files[0] != undefined && input.files[0].name == this.dish.photo) {
      console.log(true);
      this.dish.photo = input.files[0].name;
    } else if (
      input.files[0] != undefined &&
      input.files[0].name != this.dish.photo
    ) {
      let imageData = new FormData();
      imageData.append("file", input.files[0]);
      axios
        .post(dishUploadURL, imageData, {
          headers: { "Content-type": "multiplart/form-data" }
        })
        .then(() => {
          this.dish.photo = input.files[0].name;
          let dishURL = `https://localhost:5001/api/dishes/`;
          axios.put(dishURL, this.dish);
        });
    } else {
      let dishURL = `https://localhost:5001/api/dishes/`;
      axios.put(dishURL, this.dish);
    }
  }
};
</script>

<style scoped>
.dish {
  padding: 20px;
  display: grid;
  grid-template-rows: 200px repeat(6, auto);
  grid-template-columns: repeat(7, 1fr);
  grid-template-areas:
    "pic pic pic pic pic pic pic"
    "name name name name name name name"
    "desc desc desc desc desc desc desc"
    "price price price price price price price"
    "type type type type type type type"
    "high high high high high high high"
    "del del del del del del del";
  gap: 20px;
  border-radius: 20px;
}

section {
  display: grid;
  grid-template-columns: 1fr;
  gap: 3px;
  font-family: var(--paragraph);
}

.photo {
  height: 100%;
  grid-area: pic;
  text-align: center;
}

.figure {
  height: 100%;
  border-radius: 20px;
  overflow: hidden;
  position: relative;
}

.figure img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

input,
select,
textarea,
.input-highlighted label {
  border: 1px solid black;
  background: #ffffff;
  border-radius: 5px;
  padding: 5px;
}

input[type="text"],
select,
textarea,
.input-highlighted label {
  height: 35px;
}

textarea {
  resize: none;
}

input[type="number"] {
  width: 100%;
}

input[type="file"] {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  cursor: pointer;
  opacity: 0;
}

.name {
  grid-area: name;
}

.desc {
  grid-area: desc;
}

.price {
  grid-area: price;
}

.type {
  grid-area: type;
}

.highlighted {
  grid-area: high;
}

.input-highlighted {
  grid-template-columns: repeat(2, auto);
  gap: 20px;
}

.input-highlighted label {
  display: flex;
  flex-direction: row;
  align-items: center;
  font-size: 0.8em;
}

.input-highlighted label p {
  margin-left: 10px;
}

.del {
  grid-area: del;
}

.del-btn {
  border-radius: 10px;
  padding: 10px 20px;
  background: #ff0000;
  box-shadow: inset 10px 10px 100px #f50000, inset -10px -10px 100px #ff0000;
  color: white;
  transition: 0.2s ease-in-out;
}

.del-btn:hover {
  box-shadow: inset 10px 10px 100px #cc0000, inset -10px -10px 100px #ff0000;
}

@media only screen and (min-width: 1100px) {
  .dish {
    grid-template-rows: 80px;
    grid-template-columns: 80px 200px auto 90px 90px 140px 100px;
    align-items: center;
    grid-template-areas: "pic name desc price type high del";
  }

  .input-highlighted {
    gap: 10px;
  }
}
</style>