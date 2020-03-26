<template>
  <form class="upload">
    <section>
      <label>Navn</label>
      <input type="text" placeholder="Navn" id="new-dish-name" />
    </section>
    <section>
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse" id="new-dish-desc"></textarea>
    </section>
    <section>
      <label>Type</label>
      <select id="new-dish-type">
        <option disabled>Velg type</option>
        <option value="starter" selected>Starter</option>
        <option value="main">Forrett</option>
        <option value="dessert">Dessert</option>
      </select>
    </section>
    <section>
      <label>Pris</label>
      <input type="text" placeholder="99 kr" id="new-dish-price" />
    </section>
    <section>
      <label>Kommer den i flere størrelser</label>
      <select id="new-dish-packs">
        <option value="1" selected>Ja</option>
        <option value="0">Nei</option>
      </select>
    </section>
    <section>
      <label>Skal den fremheves?</label>
      <select id="new-dish-highlighted">
        <option value="1">Ja</option>
        <option value="0" selected>Nei</option>
      </select>
    </section>
    <section>
      <label>Last opp bilde</label>
      <input type="file" name="upload-img" id="new-dish-photo" />
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
      dish: [],
      newDish: {}
    };
  },
  methods: {
    addNewDish(e) {
      e.preventDefault();
      const webAPIUrl = "https://localhost:5001/api/dishes";

      this.newDish.Name = document.querySelector("#new-dish-name").value;
      this.newDish.Description = document.querySelector("#new-dish-desc").value;
      this.newDish.Type = document.querySelector("#new-dish-type").value;
      this.newDish.Price = parseInt(
        document.querySelector("#new-dish-price").value
      );
      this.newDish.Packs = parseInt(
        document.querySelector("#new-dish-packs").value
      );
      this.newDish.Highlighted = parseInt(
        document.querySelector("#new-dish-highlighted").value
      );

      let photo = document.querySelector("#new-dish-photo");
      let imageData = new FormData();
      imageData.append("file", photo.files[0]);

      this.newDish.Photo = photo.files[0].name;

      console.log(this.newDish);

      axios.post(webAPIUrl, this.newDish).then(() => {
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
  width: 100%;
  max-width: 500px;
}

.upload > section {
  display: flex;
  flex-direction: column;
  margin-bottom: 20px;
}

input:not([type="file"]),
textarea {
  background: white;
  border: 1px solid grey;
  width: 100%;
  padding: 2px;
}

textarea {
  resize: vertical;
}

button {
  background: white;
  padding: 10px 25px;
  border-radius: 30px;
  font-size: 0.9em;
  font-weight: 600;
  font-family: var(--subheading);
  width: max-content;
}
</style>