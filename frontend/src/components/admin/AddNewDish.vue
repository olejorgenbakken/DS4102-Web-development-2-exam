<template>
  <form class="upload">
    <header>
      <h3>Legg til rett</h3>
    </header>
    <section>
      <label>Navn</label>
      <input type="text" placeholder="Navn" autocomplete="off" v-model="dish.name" />
    </section>
    <section class="price">
      <label>Pris</label>
      <input type="number" placeholder="99" autocomplete="off" v-model="dish.price" />
    </section>
    <section>
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
    </section>
    <section class="photo">
      <label>Bilde</label>
      <input type="file" name="upload-img" id="new-pic" @change="showPicture" />
      <img :src="dish.photo" alt="Last opp et bilde" />
    </section>
    <section class="type">
      <label>Type</label>
      <select v-model="dish.type">
        <option default disabled selected>Velg type</option>
        <option v-for="type in dishTypes" :value="type" :key="type">{{ type }}</option>
      </select>
    </section>
    <section class="highlighted">
      <label>Skal den fremheves?</label>
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
    <button @click="addNewDish">Last opp ny rett</button>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "AddNewDish",
  data() {
    return {
      dishTypes: ["Forrett", "Maki", "Sashimi", "Nigiri", "Vegetar", "Drikke"],
      dish: {}
    };
  },
  methods: {
    showPicture() {
      let input = document.querySelector("#new-pic");
      if (input.files && input.files[0]) {
        let reader = new FileReader();
        reader.onload = e => {
          this.dish.photo = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    addNewDish(e) {
      e.preventDefault();
      let dishesURL = "https://localhost:5001/api/dishes";
      let imageData = new FormData();
      let input = this.$el.querySelector("#new-pic");
      imageData.append("file", input.files[0]);
      this.dish.price = parseInt(this.dish.price);
      this.dish.photo = input.files[0].name;
      axios.post(dishesURL, this.dish).then(() => {
        axios({
          method: "post",
          url: "https://localhost:5001/api/dishes/upload",
          data: imageData,
          config: { headers: { "Content-type": "multiplart/form-data" } }
        });
      });
    }
  }
};
</script>

<style scoped>
.upload {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  padding: 20px;
}

.upload section {
  display: grid;
  grid-template-columns: 1fr;
}
</style>