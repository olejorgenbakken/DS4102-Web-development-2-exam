<template>
  <form id="upload">
    <header>
      <h3>Last opp rett</h3>
    </header>
    <section>
      <label>Navn</label>
      <input type="text" placeholder="Navn" id="new-dish-name" autocomplete="off" />
    </section>
    <section class="price">
      <label>Pris</label>
      <input type="number" placeholder="99" id="new-dish-price" autocomplete="off" />
    </section>
    <section>
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse" id="new-dish-desc" autocomplete="off"></textarea>
    </section>
    <section class="photo">
      <label>Bilde</label>
      <input type="file" name="upload-img" id="new-dish-photo" @change="showPicture" />
      <img src="#" alt="Last opp et bilde" id="preview" />
    </section>
    <section class="type">
      <label>Type</label>
      <select id="new-dish-type">
        <option v-for="type in dishTypes" :value="type" :key="type">{{ type }}</option>
      </select>
    </section>
    <section class="highlighted">
      <label>Skal den fremheves?</label>
      <select id="new-dish-highlighted">
        <option value="1">Ja</option>
        <option value="0" selected>Nei</option>
      </select>
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
      dishTypes: ["Forrett", "Maki", "Sashimi", "Nigiri", "Vegetar", "Drikke"],
      newDish: {}
    };
  },
  methods: {
    showPicture() {
      let input = document.querySelector("#new-dish-photo");
      if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function(e) {
          document
            .querySelector("#preview")
            .setAttribute("src", e.target.result);
          document
            .querySelector("#preview")
            .setAttribute("alt", "Lastet opp bilde");
        };

        reader.readAsDataURL(input.files[0]);
      }
    },
    addNewDish(e) {
      e.preventDefault();
      const webAPIUrl = "https://localhost:5001/api/dishes";

      this.newDish.Name = document.querySelector("#new-dish-name").value;
      this.newDish.Description = document.querySelector("#new-dish-desc").value;
      this.newDish.Price = parseInt(
        document.querySelector("#new-dish-price").value
      );
      this.newDish.Type = document.querySelector("#new-dish-type").value;

      if (
        parseInt(document.querySelector("#new-dish-highlighted").value) == 1
      ) {
        this.newDish.Highlighted = true;
      } else {
        this.newDish.Highlighted = false;
      }

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
#upload {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  width: 100%;
  margin: 0 auto;
  gap: 15px;
  padding: 5px;
}

#upload section,
button {
  display: grid;
  grid-template-columns: 1fr;
  font-family: var(--paragraph);
  grid-column: 1 / span 2;
  gap: 2px;
}

header {
  font-family: var(--subheading);
}

#preview {
  width: 100%;
  min-height: 100px;
  max-height: 300px;
  object-fit: cover;
}

#new-dish-name,
#new-dish-price,
textarea,
select {
  border: 1px solid lightgray;
}

#new-dish-name,
#new-dish-price,
textarea {
  padding: 2px;
}

textarea {
  min-height: 30px;
  height: 30px;
  max-height: 130px;
  resize: vertical;
}

.type,
.highlighted {
  grid-column: span 1 !important;
}
</style>