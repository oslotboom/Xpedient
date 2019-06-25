<template>
    <div>
        <h3 class="mt-4">
            List Reordering
        </h3>

        <div class="data-entry">
            <div>Number of random reals</div>
            <div><input v-model="quantity"></div>
        </div>

        <div class="data-entry">
            <div>Minimum value</div>
            <div><input v-model="minimum"></div>
        </div>

        <div class="data-entry">
            <div>Maximum</div>
            <div><input v-model="maximum"></div>
        </div>

        <div class="data-entry">
            <div></div>
            <div><button v-on:click="GetList()">Get List</button></div>  &nbsp; <icon v-show="showSpinner" icon="spinner" pulse />
        </div>

        <table cellpadding="0" cellspacing="0" v-if="randomList">
            <tr class="display-item">
                <td></td>
                <td class="heading-item" style="border-bottom:double 3px black;">Original</td>
                <td class="heading-item" style="border-bottom:double 3px black;">Ordered</td>
            </tr>

            <tr v-for="(item, index) in randomList" class="table-row">
                <td style="width: 40px;">{{index + 1}}</td>
                <td :class="{'yellow-background': index == originalMaxIndex}" style="width: 80px; padding-left: 10px; border-bottom: solid 1px #888;">{{item}}</td>
                <td :class="{'yellow-background': index == orderedMaxIndex}" style="width: 80px; padding-left: 10px; border-bottom: solid 1px #888;">{{ orderedList[index]}}</td>
            </tr>

        </table>


    </div>
</template>

<script>
        import axios from 'axios';

export default {
  data () {
        return {
            quantity: 20,
            minimum: 0,
            maximum: 100,
            randomList: null,
            orderedList: null,
            showSpinner: false,
            originalMaxIndex: null,
            orderedMaxIndex: null,
            status: "before"
        }
        },
        methods: {
            GetList() {
                this.showSpinner = true;
                axios(
                  {
                    method: "post",
                    data: {
                      Count: this.quantity,
                      Minimum: this.minimum,
                      Maximum: this.maximum
                    },
                    url: '/api/data/GetList'
                  }
                )
                    .then(response => {
                        this.status = response.data.original.length;
                        this.randomList = response.data.original;
                        this.originalMaxIndex = this.randomList.indexOf(Math.max(...this.randomList));

                        this.orderedList = response.data.ordered;
                        this.orderedMaxIndex = this.orderedList.indexOf(Math.max(...this.orderedList));

                  })
                  .catch(error => {
                     this.status = "catch";
                  })
                  .finally(() => this.showSpinner = false)

            },

        }
}
</script>

<style>
    .data-entry { padding: 6px 0;}
    .data-entry > div {
        display: inline-block;
    }


    input { width: 80px;}

    .data-entry > div:first-child { width: 220px; text-align: right; margin-right: 4px;}

    .table-row:not(:last-child) td { border-bottom: solid 1px #888;}
    .table-row td:first-child{ width: 40px;}
    .table-row td:not(:first-child) { width: 80px; padding-left: 10px;}

    .heading-item { border-bottom:double 3px black;}

    .yellow-background { background-color: yellow; }

</style>
